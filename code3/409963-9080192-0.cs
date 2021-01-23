     using(UIImage img = UIImage.FromFile( path )) {
         using (var scaled_img = img.Scale( 250,250 )) {
             using (var data = img.AsPNG ()) {
                 data.Save( filename, true, out err );
             }
         }
     }
