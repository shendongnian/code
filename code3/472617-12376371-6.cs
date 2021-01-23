        WITH UserBusinessUnits
                (BusinessUnitID,
                BusinessName,
                ParentBusinessUnitID)
                AS
                (SELECT Bu.BusinessUnitId,
                        Bu.BusinessName,
                        CAST(NULL AS integer)
                        FROM Users U
                        INNER JOIN UserPermissions P ON P.UserID = U.UserID
                        INNER JOIN BusinessUnits Bu ON Bu.BusinessUnitId = P.BusinessUnitId
                        WHERE U.UserId = ?
                UNION ALL
                SELECT  Bu.BusinessUnitId,
                        Bu.BusinessName,
                        Bu.ParentBusinessUnitId
                        FROM UserBusinessUnits Uu
                        INNER JOIN BusinessUnits Bu ON Bu.ParentBusinessUnitID = Uu.BusinessUnitId)
        SELECT  DISTINCT
                BusinessUnitID,
                BusinessName,
                ParentBusinessUnitID
                FROM UserBusinessUnits
