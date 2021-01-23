    public static List<testMOdel> ToModelList(this List<testEntity> objlist)
            {
                List<testMOdel> list = new List<testMOdel>();
                foreach (var item in objlist)
                {
                    list.Add((Mapper.Map<testEntity, testMOdel>(item)));
                }
                return list;
            }
            public static List<testEntity> ToEntityList(this List<testMOdel> modellist)
            {
                List<testEntity> list = new List<testEntity>();
                foreach (var item in modellist)
                {
                    list.Add((Mapper.Map<testMOdel, testEntity>(item)));
                }
                return list;
            } 
