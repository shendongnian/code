     void Target_DragEnter(object sender, DragEventArgs e)
     {
         DragDropEffects effects = DragDropEffects.None;
         if (e.Data.GetDataPresent(DataFormats.FileDrop))
         {
             var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
             if (Directory.Exists(path))
                 effects = DragDropEffects.Copy;
         }
         e.Effects = effects;
     }
