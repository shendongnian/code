    var filterBrAttendence = (from atn in this._classesDataContext.BR_Attendances
                                      where atn.AttenDate == attendanceDate
                                      select new {atn.SupId, atn.PresentBR});
            var kycKist = (from aloc in this._classesDataContext.tblUsers
                           join sup in this._classesDataContext.BR_Supervisors on aloc.SupId equals sup.Id
                           where
                               (aloc.UserTypesId == 1 &&
                                ((aloc.CreatedOn <= attendanceDate && aloc.ModifyOn >= attendanceDate &&
                                  aloc.Active == false) ||
                                 (aloc.Active == true && aloc.CreatedOn <= attendanceDate &&
                                  aloc.ModifyOn <= attendanceDate)))
                           select
                               new
                                   {
                                       sup.Id,
                                       sup.Name,
                                       sup.Region,
                                       sup.Area,
                                       sup.Distribution_Name,
                                       sup.BR_Alloc,
                                       sup.Active
                                   });
            var final = (from a in kycKist
                         join b in filterBrAttendence on a.Id equals b.SupId into outer
                         from x in outer.DefaultIfEmpty()
                         select
                             new
                                 {
                                     a.Name,
                                     //a.Region,
                                     a.Area,
                                     a.Distribution_Name,
                                     a.BR_Alloc,
                                     a.Active,
                                     PresentBR = (x!=null)?x.PresentBR.ToString():"Absent"
                                 });
