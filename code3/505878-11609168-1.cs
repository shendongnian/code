	internal class Content  {  
		
		internal Master master { get; set; }
		
		internal Content(Master pmaster) {     
			master=pmaster;
		}
		
		internal Content() {     
			master = new Master() { content = this };
		}  
	}
	
	public class Master {  
		
		internal Content content { get; set; }  
		
		internal Master() {     
			content = new Content(this);
		}  
		// this is optional and can be omitted, if not needed:  
		internal Master(Content pcontent) {     
			content = pcontent;
		}  
	} 
