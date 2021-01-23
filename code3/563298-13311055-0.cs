    using umbraco.cms.businesslogic.web;
    using umbraco.cms.businesslogic;
    using umbraco.BusinessLogic;
    
    namespace MyWebsite {
    	public class MyApp : ApplicationBase {
    		public MyApp()
    			: base() {
    			Document.AfterPublish += new Document.PublishEventHandler(Document_AfterPublish);
    		}
    
    		void Document_AfterPublish(Document sender, PublishEventArgs e) {
    			if (sender.ContentType.Alias == "DoctypeAliasOfDocumentYouWantToCopy") {
    				int parentId = 0; // Change to the ID of where you want to create this document as a child.
    				Document d = Document.MakeNew("Name of new document", DocumentType.GetByAlias(sender.ContentType.Alias), User.GetUser(1), parentId)
					foreach (var prop in sender.GenericProperties) {
						d.getProperty(prop.PropertyType.Alias).Value = sender.getProperty(prop.PropertyType.Alias).Value;
					}
					d.Save();
					d.Publish(User.GetUser(1));
    			}
    		}
    	}
    }
