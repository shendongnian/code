        public bool GetElectricalStatus(string printName)
        {
            List<object> eGoodList = new List<object>();
            var eGoodCountQuery =
                from row in singulationOne.Table.AsEnumerable()
                where row.Field<String>("print") == printName
                select row.Field<String>("electrical");
            foreach (var eCode in eGoodCountQuery)
            {
                if (!string.IsNullOrEmpty(eCode.ToString()))
                {
                    int? eCodeInt = Convert.ToInt32(eCode);
                    if (eCodeInt != null &&
                        (eCodeInt >= 100 && eCodeInt <= 135) || eCodeInt == 19)
                    {
                        eGoodList.Add(eCode);
                    }
                }
            }
            if (eGoodList.Count() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
