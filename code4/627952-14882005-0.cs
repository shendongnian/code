    var res = (from positions in context.Lloyds_ETAs
              join vessels in context.Lloyds_Vessels on positions.ImoNumber equals vessels.imo_no
              select new PositionData {
                  ImoNo = positions.ImoNumber,
                  PositionCordinates = positions.AIS_Latest_Position,
                  CompassOverGround = positions.Compass_over_Ground_Heading,
                  VesselId = positions.Vessel_ID,
                  Equipment = vessels.vessel_type,
                  Updated = positions.Last_Place_Location
               })
               .GroupBy(x => x.ImoNo)
               .Select(g => g.OrderByDescending(pd => pd.Updated).First());
