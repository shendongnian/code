         public static void Start()
        {
            DataTable Result = new DataTable();
            var ShowResult = from r in Result.AsEnumerable()
                             where Convert.ToInt32(r.Field<double>("ASLVAM") / r.Field<double>("GEST")) > 60
                             orderby Convert.ToInt32(r.Field<double>("ASLVAM") / r.Field<double>("GEST")) descending
                             select r;
            DataTable newDataTbl = ShowResult.CopyToDataTable();
            var anonType = newDataTbl.AsEnumerable()
                .Select(r => new
                             {
                                 pascode = r.Field<string>("PAS_CODE"),
                                 melli = r.Field<string>("CODEMELI"),
                                 name = r.Field<string>("NAM"),
                                 family = r.Field<string>("FAMILY"),
                                 bycode = r.Field<string>("BAYGANI"),
                                 jancode = r.Field<string>("CODEJANBAZ"),
                                 darsad = r.Field<int>("DARSAD"),
                                 ostan = r.Field<string>("OSTAN_N"),
                                 vacode = r.Field<string>("VA_CODE"),
                                 moin = r.Field<string>("VA_MOIN"),
                                 onvan = r.Field<string>("TAFZILI"),
                                 aslvam = r.Field<double>("ASLVAM"),
                                 gest = r.Field<double>("GEST"),
                                 //tededGestKol = Convert.ToInt32(r.Field<double>("ASLVAM") / r.Field<double>("GEST")),
                                 mandeVam = r.Field<double>("MANDE_VAM"),
                                 dPardakht = r.Field<string>("DATE_P")
                             }
                       );
        }
