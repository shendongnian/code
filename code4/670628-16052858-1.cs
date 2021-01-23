        var books = db.Books
            .Where((book) =>
            {
                foreach (var filterChar in fc)
	            {
		            if (!book.BookCharacteristic.Contains(new BookCharacteristic() {CharacteristicID = filterChar.CharID, Value = filterChar.CharVal},
                                                            new BookCharacteristicEqualityComparer()))
                        return false;
	            }
                return true;
            });
