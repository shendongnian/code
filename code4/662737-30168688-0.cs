            using (SchoolBriefcaseEntities datamodel = new SchoolBriefcaseEntities())
            {
                List<Compliance> compliance = new List<Compliance>();
                IList<ComplianceModel> complianceModel;
                if (HttpContext.Current.User.IsInRole("SuperAdmin"))
                {
                    compliance = datamodel.Compliances.Where(c => c.School.DistrictId == districtId).ToList();
                }
            }
