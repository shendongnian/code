    recordsList.ListOfRecords = new StudentRecordsBAL().GetStudentsList().Select(q => 
				{
					var attendanceList = new AttendanceBAL().GetAttendanceListOf(q._RollNumber);
					if (attendanceList == null)
						return null;
					return new StudentRecords()
						{
							_RollNumber = q._RollNumber,
							_Class = q._Class,
							_Name = q._Name,
							_Address = q._Address,
							_City = q._City,
							_State = q._State,
							_Subjects = q._Subject,
							_AttendedDays = attendanceList.Where(date => date != null).Select(date => new DateTime(date._Date.Year, date._Date.Month, date._Date.Day)).Distinct().ToList(),
							_AttendedSubjects = GetAttendedSubjects(q._RollNumber)
						};
				}).Where(q => q != null).ToList(); 
