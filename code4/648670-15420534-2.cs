    var subs = (from doc in dc.Documents
                        join u in dc.Users on doc.OwnedByUserID equals u.ID
                        where doc.OwnedByUserID == usr && doc.LibraryID == lib
                        orderby doc.UploadDT descending
                        select new StudentDocuments
                         { 
                            DocID = doc.ID, 
                            Assignment = doc.Library.Name, 
                            Submitted = doc.UploadDT,
                            Student = u.FullName
                         }).AsEnumerable().ToList();
