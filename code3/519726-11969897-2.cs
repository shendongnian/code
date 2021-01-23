    foreach (Person person in Persons)
    {
        // Edit: After reading the comment below, I 
        // updated the methods to return an XmlWriter. This
        // way, you should be able to contiune working with the 
        // same instance:
        if(typeOf(Student).IsInstanceOfType(person)){
            xmlOut = AppendStudentInfo(person, xmlOut);
        }else if(typeOf(Teacher).IsInstanceOfType(person){
            xmlOut = AppendTeacherInfo(person, xmlOut);
        }else{
            xmlOut = AppendPersonInfo(person, xmlOut);
        }
    }
    xmlOut.WriteEndElement();
    xmlOut.Close();
    (...)
    
