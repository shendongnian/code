     *[HttpPost()]
            public ActionResult SaveStudentInvoice(IEnumerable<Student.Models.vwStudent> students)
            {
                DataContext db = new DataContext();
                 foreach(Student.Models.vwStudent student in students){
                    Invoice Inv = new Invoice();
                    {
                        Inv .StudentID= student.StudentID;
                        Inv .PastDueAmount= student.PastDueAmount;   
                        Inv .PastDueDays= student.PastDueDays;                 
                    };
            
                    db.Invoices.InsertOnSubmit(Inv);
        }
                    db.SubmitChanges();
            
                    return View();
            
            }
