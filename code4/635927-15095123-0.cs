     int marcasint;
     if(Int32.TryParse(marcas, out marcasint))
     {
        return View(descripcion.Where(x => x.MarcaID == marcasint));
     }
     else
     {
        //eles part
     }
