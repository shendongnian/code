        [Fact]
        public async Task QueryUsingObjectId()
        {
            var filter = Builders<CosmosParkingFactory>.Filter.Eq("_id", new ObjectId("5b57516fd16cb04bfc35fcc6"));
            var entity = stocksCollection.Find(filter);
            var stock = await entity.SingleOrDefaultAsync();
            Assert.NotNull(stock);
            var idString = "5b57516fd16cb04bfc35fcc6";
            var stringFilter = "{ _id: ObjectId('" + idString + "') }";
            var entityStringFiltered = stocksCollection.Find(stringFilter);
            var stockStringFiltered = await entityStringFiltered.SingleOrDefaultAsync();
            Assert.NotNull(stockStringFiltered);
        }
