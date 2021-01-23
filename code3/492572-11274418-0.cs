    namespace MvcApplication1.ViewModels
    {
        public class AuditScheduleEdit
        {
            public Models.AuditSchedule AuditScheduleInstance { get; set; }
            public List<SpacerProductCheckBoxHelper> SpacerProductCheckBoxHelperList { get; set; }
            public void InitializeSpacerProductCheckBoxHelperList(List<Models.SpacerProduct> SpacerProductList)
            {
                if (this.SpacerProductCheckBoxHelperList == null)
                    this.SpacerProductCheckBoxHelperList = new List<SpacerProductCheckBoxHelper>();
                if (SpacerProductList != null
                    && this.AuditScheduleInstance != null)
                {
                    this.SpacerProductCheckBoxHelperList.Clear();
                    SpacerProductCheckBoxHelper spacerProductCheckBoxHelper;
                    string spacerTypes =
                        string.IsNullOrEmpty(this.AuditScheduleInstance.spacer_type) ?
                        string.Empty : this.AuditScheduleInstance.spacer_type;
                    foreach (Models.SpacerProduct spacerProduct in SpacerProductList)
                    {
                        spacerProductCheckBoxHelper = new SpacerProductCheckBoxHelper(spacerProduct);
                        if (spacerTypes.Contains(spacerProduct.SpacerName))
                            spacerProductCheckBoxHelper.Checked = true;
                        this.SpacerProductCheckBoxHelperList.Add(spacerProductCheckBoxHelper);
                    }
                }
            }
            public void PopulateCheckBoxsToSpacerType()
            {
                this.AuditScheduleInstance.spacer_type = string.Empty;
                var spacerTypes = this.SpacerProductCheckBoxHelperList.Where(x => x.Checked)
                                      .Select<SpacerProductCheckBoxHelper, string>(x => x.SpacerName)
                                      .AsEnumerable();
                this.AuditScheduleInstance.spacer_type = string.Join(", ", spacerTypes);
            }
            public class SpacerProductCheckBoxHelper : Models.SpacerProduct
            {
                public bool Checked { get; set; }
                public SpacerProductCheckBoxHelper() : base() { }
                public SpacerProductCheckBoxHelper(Models.SpacerProduct spacerProduct)
                {
                    this.SpacerProductID = spacerProduct.SpacerProductID;
                    this.SpacerName = spacerProduct.SpacerName;
                    this.SpacerBrand = spacerProduct.SpacerBrand;
                }
            }
        }
    }
