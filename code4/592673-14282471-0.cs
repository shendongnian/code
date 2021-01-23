    foreach (RepeaterItem item in StringChangeRepeater.Items)
                {
                    if (item.ItemType == ListItemType.Item || (item.ItemType == ListItemType.AlternatingItem))
                    {
                        HiddenField stringchangeIDHidden = item.FindControl("stringchangeID") as HiddenField;
                        int stringchangeID = Convert.ToInt32(stringchangeIDHidden.Value);
                        var getcurrentrecord = (from s in db.stringchange_view
                                                where s.ID == stringchangeID
                                                select new
                                                {
                                                    s.changedate
                                                }).First();
                        Label timeBetweenChangesLabel = item.FindControl("timeBetweenChangesLabel") as Label;
                        DateTime changedate1 = Convert.ToDateTime(getcurrentrecord.changedate);
                        TimeSpan changedateSpan = changedateX - changedate1;
                        TimeSpan changedateSpan2 = changedate1 - Convert.ToDateTime(getcurrentrecord.changedate);
                        timeBetweenChangesLabel.Text = changedateSpan.Days.ToString();
                        changedateX = changedate1;
                    }
                }
