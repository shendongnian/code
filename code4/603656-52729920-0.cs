    //Object can be whichever type as you wish
    List<Object> example = new List<Object>();
    
    var listItemExamples = example
    	.Select(a => new Func<ListItem>(() => {
    				ListItem item = new ListItem(a.PropropertyA.ToString(), a.PropropertyB.ToString() );
    				item.Attributes["data-PropropertyC"] = a.PropropertyC.ToString();
    				return item;
    			})())
    	.ToArray();
    			
    dropListUserImages.Items.AddRange(listItemExamples);
