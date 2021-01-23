        public void Create()
        {
            using (var context = new INOBASEEntities())
            {
                // first i need to map model 'came from the view' to entity 
               var _ent = (Equipment)Mapper.Map(this, typeof(EquipmentModel), typeof(Equipment));
                
                context.Entry(_ent).State = System.Data.Entity.EntityState.Added;
                // I use multiselect list on the view for operators, so i have just ids of users, i get the operator entity from user table and add them to equipment entity
                foreach(var id in OperatorIds)
                {
                    AspNetUsersExtended _usr = context.AspNetUsersExtended.Where(u => u.Id == id).FirstOrDefault();
                    // this is operator collection
                    _ent.AspNetUsersExtended2.Add(_usr);
                }
                context.SaveChanges();
                Id = _ent.Id;
            }
        }
        public void Update()
        {
            using (var context = new INOBASEEntities())
            {
                var _ent = (Equipment)Mapper.Map(this, typeof(EquipmentModel), typeof(Equipment));
                context.Entry(_ent).State = System.Data.Entity.EntityState.Modified;
                
                var parent = context.Equipment
                            .Include(x => x.AspNetUsersExtended2)//include operators
                            .Where(x => x.Id == Id).FirstOrDefault();
                parent.AspNetUsersExtended2.Clear(); // get the parent and clear child collection
                foreach (var id in OperatorIds)
                {
                    AspNetUsersExtended _usr = context.AspNetUsersExtended.Where(u => u.Id == id).FirstOrDefault();
                    parent.AspNetUsersExtended2.Add(_usr);
                }
                // this line add operator list to parent entity, and also update equipment entity 
                context.SaveChanges();
            }
        }
