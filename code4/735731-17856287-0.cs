     public ActionResult Edit(string RID)
            {
                int _RID = 0;
                int.TryParse(RID, out _RID);
                RegisterModel model = new RegisterModel();
                if (_RID > 0)
                {
                   var re = (from r in _context.Registrations where r.RID == _RID select r).First();
                   model.RID = _RID;
                   model.REName = re.REName;
                   model.REAddress = re.REAddress;
                   model.REPhoneNo = re.REPhoneNo;
                    return View(model);
                }
                else
                {
                return View();
                }
            }
