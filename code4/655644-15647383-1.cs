    internal static Bug Deserialize(string filePath)
        {
            XDocument doc = XDocument.Load(filePath);
            Bug bug = new Bug();
            bug.ID = int.Parse(doc.Root.Element("ID").Value);
            bug.ChangedDate = DateTime.Parse(doc.Root.Element("ChangedDate").Value);
            foreach (var el in doc.Root.Element("Fields").Elements())
            {
                XAttribute fieldName = el.Attributes("Name").Single();
                XAttribute fieldValue = el.Attributes("Value").Single();
                switch (fieldName.Value.ToString())
                {
                    case "State":
                        bug.State = fieldValue.Value.ToString();
                        break;
                    case "Area Path":
                        bug.AreaPath = fieldValue.Value.ToString();
                        break;
                    case "Title":
                        bug.Title = fieldValue.Value.ToString();
                        break;
                    case "Status":
                        bug.Status = fieldValue.Value.ToString();
                        break;
                    case "SubStatus":
                        bug.SubStatus = fieldValue.Value.ToString();
                        break;
                    case "Opened By":
                        bug.OpenedBy = fieldValue.Value.ToString();
                        break;
                    case "ChangedBy":
                        bug.ChangedBy = fieldValue.Value.ToString();
                        break;
                    case "Opened Date":
                        bug.OpenedDate = DateTime.Parse(fieldValue.Value.ToString());
                        break;
                    case "Resolved Date":
                        bug.ResolvedDate = DateTime.Parse(fieldValue.Value.ToString());
                        break;
                    case "Assigned To":
                        bug.AssignedTo = fieldValue.Value.ToString();
                        break;
                    case "Issue Type":
                        bug.IssueType = fieldValue.Value.ToString();
                        break;
                    case "Issue Subtype":
                        bug.IssueSubtype = fieldValue.Value.ToString();
                        break;
                    case "Priority":
                        bug.Priority = fieldValue.Value.ToString();
                        break;
                    case "Severity":
                        bug.Severity = fieldValue.Value.ToString();
                        break;
                    case "Keywords":
                        bug.Keywords = fieldValue.Value.ToString();
                        break;
                    case "ScreenID":
                        bug.ScreenID = fieldValue.Value.ToString();
                        break;
                    case "ResolvedBy":
                        bug.ResolvedBy = fieldValue.Value.ToString();
                        break;
                    case "Resolution":
                        bug.Resolution = fieldValue.Value.ToString();
                        break;
                    case "ReproSteps":
                        bug.State = fieldValue.Value.ToString();
                        break;
                    case "HowFound":
                        bug.State = fieldValue.Value.ToString();
                        break;
                    case "FullHistory":
                        bug.State = fieldValue.Value.ToString();
                        break;
                    case "EverChangedBy":
                        bug.State = fieldValue.Value.ToString();
                        break;
                }
            }
            return bug;
        }
