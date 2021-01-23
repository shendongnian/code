      ID targetId = ID.NewID;
      using (var db = new Db
        {
          new DbItem("home")
            {
              // Field 'Url' is an internal link which targets the 'target' item
              { "Url", "<link linktype=\"internal\" id=\"{0}\" />".FormatWith(targetId) }
            },
          new DbItem("target", targetId)
        })
      {
        Item item = db.GetItem("/sitecore/content/home");
        LinkField linkField = item.Fields["Url"];
        linkField.IsInternal.Should().BeTrue();
        linkField.TargetItem.Should().NotBeNull();
        linkField.TargetItem.Paths.FullPath.Should().Be("/sitecore/content/target");
      }
