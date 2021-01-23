      var folder = ge1.createFolder("Mobiles");
      folder.setName("Mobiles");
      kmlTreeView1.ParseKmlObject(folder);
      kmlTreeView1.NodeMouseClick += (o, e) =>
      {
          if (e.Button == MouseButtons.None)
          {
            // no actual mouse click...
            return;
          }
          // handle user interactions
      };
