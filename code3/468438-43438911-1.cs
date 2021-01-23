    public static class HtmlHelpr{
    
    		public static HtmlDocument HtmlDocumentFromFile(this string PathToHtml){
    			using(WebBrowser wb = new WebBrowser()){			
    				string s = File.ReadAllText(PathToHtml);
    				wb.ScriptErrorsSuppressed = true;
    				wb.DocumentText = s;
    				var hd = wb.Document;
    				hd.Write(s);
    				return	hd;
    			}
    		}
    	}
