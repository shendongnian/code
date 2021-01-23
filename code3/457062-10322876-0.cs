    Response.Clear();
    Response.ContentType = "application/CSV";
    Response.AddHeader("content-disposition", "attachment; filename=\"" + filename + ".csv\"");
    Response.Write("email","f_name","l_name","c_name","ids" "abc1@test.com","CG","Wander","C1","" "abc2@Atest.COM","Virginia","Dale","A & D");
    Response.End();
