    // Excuse me for syntax, have no IDE on this PC.  
        class AC:IA  
        {  
           IA ref;  
           AC(IA ref)  
           {  
              this.ref = ref;  
           }  
           public void ChangeReference(IA newRef) { ref = newRef;}  
       
           public static operator = (IA assignedObj)  
           {  
              return (assignedObject is AC) ? assignedObject : new AC(assignedObj);
           }
           // implementation of all methods in A
           public override string ToString() { return ref.ToString(); }  
           ...  
         }
