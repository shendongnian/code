    MyClass MyObject = new MyClass();
         MemberInfo [] myMemberInfo; 
         // Get the type of the class 'MyClass'.
         Type myType = MyObject.GetType(); 
         // Get the public instance members of the class 'MyClass'. 
         myMemberInfo = myType.GetMembers(BindingFlags.Public|BindingFlags.Instance);
         Console.WriteLine( "\nThe public instance members of class '{0}' are : \n", myType); 
         for (int i =0 ; i < myMemberInfo.Length ; i++)
         {
            // Display name and type of the member of 'MyClass'.
            Console.WriteLine( "'{0}' is a {1}", myMemberInfo[i].Name, myMemberInfo[i].MemberType);
         }
