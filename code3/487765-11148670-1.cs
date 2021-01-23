    public class  DAL
        {
            public void Insert(UnitBase unit)
            {
                switch (unit.TableType)
                {
                    case  TableTypeEnum.Template:
                        //insert into the template table
                        break;
                    case TableTypeEnum.TestPlan:
                         //insert into the testplan table
                        break;
                }
            }
    
        }
