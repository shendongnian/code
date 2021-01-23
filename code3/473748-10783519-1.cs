    class DBLibraryRepository : ILibraryRepository {
        public Save(Library lib) {
            //hibernate session 
            //and you'll have mapping defined for all entities
            //and relations between library and stuff, so books are saved automatically
            _session.Save(lib)
        }
    }
    class XMLLibraryRepository : ILibraryRepository {
        public Save(Library lib) {
            //serialized does all the work, so no additional loops here
            var xml = Serialize(lib);
            SaveToFile(xml);
        }
    }
    class CSVLibraryRepository : ILibraryRepository {
        public Save(Library lib) {
            //for example, save library to lib.csv, books - to books.csv.
            //add mappers to do real work, but we'd take care of separation 
            //of books and library manually.
            // (in case of ORM - it has own mappers, 
            //  for XML - serializator is mapper itself)
            var data = LibraryCSVDataMapper.Map(lib);
            data.Save();
            foreach(var book in lib.Books){
                data = BookCSVDataMapper.Map(book);
                data.Save();
            }
        }
    }
