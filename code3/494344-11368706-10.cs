		internal ActionResponse CheckMessages() //Action Response is a custom class of mine to store some data coming from pages
			{
			//go to messages
			HtmlDocument doc = WbLink.Document; //wbLink is a referring link to a webBrowser istance
			HtmlElement ele = doc.GetElementById("message_alert_box");
			if (ele == null)
				return new ActionResponse(false);
			
			object obj = ele.DomElement;
			System.Reflection.MethodInfo mi = obj.GetType().GetMethod("click");
			mi.Invoke(obj, new object[0]);
			semaphoreForDocCompletedEvent = WaitForDocumentCompleted();  //This is a simil-waitOne statement (1)
			if (!semaphoreForDocCompletedEvent)
				throw new Exception("sequencing of Document Completed events is failed.");
			//get the list
			doc = WbLink.Document;
			ele = doc.GetElementById("mailz");
			if (!ele.WaitForAvailability("mailz", Program.BrowsingSystem.Document, 10000)) //This is a simil-waitOne statement (2)
				ele = doc.GetElementById("mailz");
			ele = doc.GetElementById("mailz");
			//this contains a tbody
			HtmlElement tbody = ele.FirstChild;
			//count how many elemetns are espionage reports, these elements are inline then counting double with their wrappers on top of them.
			int spioCases = 0;
			foreach (HtmlElement trs in tbody.Children)
			{
				if (trs.GetAttribute("id").ToLower().Contains("spio"))
					spioCases++;
			}
 
			int nMessages = tbody.Children.Count - 2 - spioCases;
			//create an array of messages to store data
			GameMessage[] archive = new GameMessage[nMessages];
 
			for (int counterOfOpenMessages = 0; counterOfOpenMessages < nMessages; counterOfOpenMessages++)
			{
				//open first element
				WbLink.ScriptErrorsSuppressed = true;
				ele = doc.GetElementById("mailz");
				//this contains a tbody
				tbody = ele.FirstChild;
 
				HtmlElement mess1 = tbody.Children[1];
				int idMess1 = int.Parse(mess1.GetAttribute("id").Substring(0, mess1.GetAttribute("id").Length - 2));
				//check if subsequent element is not a spio report, in case it is then the element has not to be opened.
				HtmlElement mess1Sibling = mess1.NextSibling;
				if (mess1Sibling.GetAttribute("id").ToLower().Contains("spio"))
				{
					//this is a wrapper for spio report
					ReadSpioEntry(archive, counterOfOpenMessages, mess1, mess1Sibling);
					//delete first in line
					DeleteFirstMessageItem(doc, ref ele, ref obj, ref mi, ref tbody);
					semaphoreForDocCompletedEvent = WaitForDocumentCompleted(6); //This is a simil-waitOne statement (3)
				}
				else
				{
					//It' s anormal message
					OpenMessageEntry(ref obj, ref mi, tbody, idMess1); //This opens a modal dialog over the page, and it is not generating a DocumentCompleted Event in the webBrowser
 
					//actually opening a message generates 2 documetn completed events without any navigating event issued
					//Application.DoEvents();
					semaphoreForDocCompletedEvent = WaitForDocumentCompleted(6);
 
					//read element
					ReadMessageEntry(archive, counterOfOpenMessages);
 
					//close current message
					CloseMessageEntry(ref ele, ref obj, ref mi);  //this closes a modal dialog therefore is not generating a documentCompleted after!
					semaphoreForDocCompletedEvent = WaitForDocumentCompleted(6);
					//delete first in line
					DeleteFirstMessageItem(doc, ref ele, ref obj, ref mi, ref tbody); //this closes a modal dialog therefore is not generating a documentCompleted after!
					semaphoreForDocCompletedEvent = WaitForDocumentCompleted(6);
				}
			}
			return new ActionResponse(true, archive);
		}
