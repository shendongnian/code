        //In Table Adapter    
        protected override void Dispose(bool disposing)
        {
          base.Dispose(disposing);
          this.Adapter.Dispose();
        }
