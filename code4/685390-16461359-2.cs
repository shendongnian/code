    @using umbraco.cms.businesslogic.media;
    @using uComponents.Core;
    @using uComponents.Core.uQueryExtensions;
    @using System
    @{
      // Set default media root node id
      int rootNodeId = -1;
      // Get media node and iterate the children
      var m = new Media(rootNodeId);
      var imagesAndFolders = m.GetChildMedia();
      var sortedList = m.GetChildMedia().OrderBy(y => y.Text).OrderBy(x => x.ContentType.Alias);
    
            @{
              foreach (var c in sortedList)
              {
                var type = c.ContentType.Alias;
                switch (type)
                {
                case "Folder":
                    //drill into folder
                    break;
                default:
                    var filePath = c.GetPropertyAsString("umbracoFile");
                    var thumbPath = c.GetPropertyAsString("umbracoFile").Replace(".","_thumb.");
                    var width = c.GetPropertyAsString("umbracoWidth");
                    var height = c.GetPropertyAsString("umbracoHeight");
            
                      //allowing you to build a table of images
                      <a href="@filePath">@c.Text</a>
                      <a href="@filePath" class="imagePreview">preview &raquo;</a>
                      <a href="@filePath" itemprop="contentURL" download="@c.Text"><img itemprop="thumbnailUrl" src="@thumbPath" alt="@c.Text" /></a>
                    break;
                    }
                }
              }
    }
