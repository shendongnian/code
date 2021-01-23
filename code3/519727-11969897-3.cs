    // (Edit: Updated to return an XmlWriter)
    private XmlWriter AppendStudentInfo(Person person, XmlWriter xmlOut){
        
        Student student = (Student) person;
        // For teacher, use this instead:
        // Teacher teacher = (Teacher) person;
        xmlOut.WriteStartElement("Student");
        xmlOut.WriteAttributeString("Email", student.Email);
        xmlOut.WriteElementString("Firstname", student.FirstName);
        xmlOut.WriteElementString("Lastname", student.LastName);
        xmlOut.WriteElementString("AssessmentGrade",
                                  student.AssessmentGrade.ToString());
        xmlOut.WriteElementString("AssignmentGrade", 
                                  student.AssignmentGrade.ToString());
        xmlOut.WriteEndElement();
        
        // (Edit: Updated to return an XmlWriter)
        return xmlOut;
    }
    
