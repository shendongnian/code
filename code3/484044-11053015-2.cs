        public void UpdateForMyView1(MyUpdateAuthorDto dto)
        {
            var entityAuthor = this.dbContext.EntityAuthors.Find(dto.AuthorId);
            this.dbContext.Entry(entityAuthor).CurrentValues.SetValues(dto);
            this.dbContext.SaveChanges();
        }
