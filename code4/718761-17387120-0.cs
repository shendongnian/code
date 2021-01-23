    var report= (from u in myDb.TBL_TRANSAKSI_MKN_MNMs.AsEnumerable()
      where u.TGL_TRANSAKSI.Value.Date.Equals(dateTimePicker1.Value.Date)
      join l in myDb.TBL_DETAIL_TRANSAKSIs.AsEnumerable() on u.ID_NOTA equals l.ID_NOTA
      join m in myDb.TBL_MKN_MNMs.AsEnumerable() on l.ID_MKN_MNM equals m.ID_MKN_MNM
      group new { u, l, m } by new { m.NAMA_MKN_MNM, m.HARGA_JUAL, u.TGL_TRANSAKSI, l.ID_MKN_MNM, u.USERNAME, l.Jumlah }
      into grp                 
      select new MyClass
      {                         
          MakanMinum = grp.Key.NAMA_MKN_MNM,
          HargaJual = grp.Key.HARGA_JUAL,
          Stok = grp.Key.Jumlah,  //you already group by it ,so you cannot sum it.
          Tanggal =  grp.Key.TGL_TRANSAKSI,
          Jumlah =(grp.Key.HARGA_JUAL *  grp.Key.Jumlah),
          Total = grp.Sum(grouptotal => grp.Key.HARGA_JUAL *  grp.Key.Jumlah),
          Username = grp.Key.USERNAME
      }).Distinct(new MyClassComparer());
    class MyClass
    {
      public int MakanMinum {get;set;}
      pubic int HargaJual {get;set;}
      ...
    }
    class MyClassComparer : IEqualityComparer<MyClass>
    {
       
        public bool Equals(MyClass x, MyClass y)
        {
    
            if (Object.ReferenceEquals(x, y)) return true;
    
          
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
    
          
            return x.MakanMinum  == y.MakanMinum  && x.HargaJual= y.HargaJual;
        }
    
        public int GetHashCode(MyClass m)
        {
           
            if (Object.ReferenceEquals(m, null)) return 0;
    
            return m.MakanMinum.GetHashCode()^ m.HargaJual.GetHashCode();
        }
    
    }
