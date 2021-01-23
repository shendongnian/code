    public void Save2(Member newMember)
            {
                using (var Context = new NoxonEntities())
                {
                    Context.Attach(newMember);
                    Context.ObjectStateManager.ChangeObjectState(newMember, EntityState.Modified);
                    Context.SaveChanges();
                }
            }
