         CompositionTarget.Rendering += CompositionTarget_Rendering;
     }
     void CompositionTarget_Rendering(object sender, EventArgs e)
      {
         _bitmap = new WriteableBitmap(stackPanel, null);
         _bitmap.Invalidate();
      }
