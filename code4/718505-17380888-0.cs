    var id = (from u in myDb.TBL_TRANSAKSI_MKN_MNMs
		where u.GL_TRANSAKSI.Value.Date.Equals(dateTimePicker1.Value.Date)
                  join l in myDb.TBL_DETAIL_TRANSAKSIs on u.ID_NOTA equals l.ID_NOTA
                  //into g1
                  join m in myDb.TBL_MKN_MNMs on l.ID_MKN_MNM equals m.ID_MKN_MNM
                  //into g
                  group new {u,l,m} by new {u.TGL_TRANSAKSI, m.NAMA_MKN_MNM, m.HARGA_JUAL, l.ID_MKN_MNM, u.USERNAME}                      
                  into grp
                  select new MyClass
                  {
                      MakanMinum = grp.Key.NAMA_MKN_MNM,
                      HargaJual = grp.Key.HARGA_JUAL,
                      sumStok = grp.Sum(groupedthing => groupedthing.l.ID_MKN_MNM),
                      Tanggal = grp.Key.TGL_TRANSAKSI,
                      Jumlah = grp.Key.HARGA_JUAL * grp.Sum(groupedthing => groupedthing.l.ID_MKN_MNM),
                      Total = grp.Sum(grouptotal => grp.Key.HARGA_JUAL * grp.Sum(groupedthing => groupedthing.l.ID_MKN_MNM)),
                      Username = grp.Key.USERNAME
                  });
    class MyClass
    {
      public string MakanMinum {get;set;}
      .....
    }
