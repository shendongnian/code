        public void UpdateScalarAuthorProperties(int authorId, object dto)
        {
            var entityAuthor = this.dbContext.EntityAuthors.Find(authorId);
            this.dbContext.Entry(entityAuthor).CurrentValues.SetValues(dto);
            this.dbContext.SaveChanges();
        }
