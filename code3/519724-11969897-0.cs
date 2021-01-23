    foreach (Person person in Persons)
    {
        if(typeOf(Student).IsInstanceOfType(person)){
            AppendStudentInfo(person, xmlOut);
        }else if(typeOf(Teacher).IsInstanceOfType(person){
            AppendTeacherInfo(person, xmlOut);
        }else{
            AppendPersonInfo(person, xmlOut);
        }
    }
    xmlOut.WriteEndElement();
    xmlOut.Close();
    (...)
    
