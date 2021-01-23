        public class Result
        {
            public int Adi { get; set; }
            
            public int Soy { get; set; }
        }
  
        public IEnumerable<Result> SearchStudent(string o)
        {
            return
                from d in context.ogrencis
                where d.ogrenci_id    
                select new Result
                {
                    Adi = d.ogrenci_adi,
                    Soy = d.ogrenci_soyadi
                };
        }
