     if (Request.Form["Enroll"] != null)
                    {
                        string[] selected = Request.Form["Enroll"].Split(',');
                        if (selected != null)
                        {
                            if (selected.Count() != 0)
                            {
                                int k = 0;
                                foreach (var item in selected)
                                {
                                    var TraineeId = Convert.ToInt32(item[k].ToString());
                                    var sessionid = Convert.ToInt32(Session["user"].ToString());
                                    var id = db.EnrollTrainee.Where(i => i.TraineeID == TraineeId
                                                                    && i.TrainerID == sessionid);
                                    var idlist = id.ToArray<EnrollTrainee>();//Added New Line
                                    if (idlist != null)
                                    {
                                        foreach (var a in idlist)
                                        {
                                            EnrollTrainee delete = db.EnrollTrainee.Find(a.id);
                                            db.EnrollTrainee.Remove(delete);
                                            db.SaveChanges();                                           
                                        }
                                    }
                                    k++;
                                }
                            }
                        }
                        populatelistbox();
                        return View();
                    }
