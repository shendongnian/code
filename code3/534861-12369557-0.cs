      [WebMethod]
    public static string get_runtime_values(string get_ajax_answer_title,string get_ajax_answer_des)
        {  string result;
           if (get_ajax_answer_title.Equals("") && (get_ajax_answer_title.Equals("")))
            {
                result="null";
            }
            else
            {
                int got_question_id = getting_question_id;
                DataHandler.breg obj = new DataHandler.breg();
                obj.add_anwers(got_question_id, get_ajax_answer_title, get_ajax_answer_des);
                result="inserted";
           }
            querystring object_new = new querystring();
            object_new.show();
    return result;
           }
