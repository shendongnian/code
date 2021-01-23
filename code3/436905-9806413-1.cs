    for (int i = 0; i < minimun;i++)
    {
        if (splitControlTypeNames[i].tostring() == "textbox" && splitDatatypeNames[i].tostring() == "string")
            {
                //Response.Write("_Student." + fieldName + "= " + controlName + ".Text;");
                //Also, a parametric string would be better ;)
                string result = string.format("_Student.{0}= {1}.Text;",splitFieldnames[0].tostring(),SplitControlNames[0].tostring());
                Response.Write(result);
                l++;
            }
    }
