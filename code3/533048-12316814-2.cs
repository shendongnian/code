        public void addNewBtoA(B newEntity, A existingEntity) {
            _myContext.Attach(existingEntity);
            existingEntity.B.Add(newEntity);
            myContext.SaveChanges();
        }
