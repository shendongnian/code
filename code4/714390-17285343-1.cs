    adapter.InsertCommand = connection.CreateCommand();
    adapter.InsertCommand.CommandText = "insert into [subject] (name) values (@name); insert into studentsubject (student_id, subject_id, mark) values (1, @@identity, @mark)";
    adapter.InsertCommand.Parameters.AddRange(new SqlParameter[] {
        new SqlParameter("@name", SqlDbType.Char, 10, "name"),
        new SqlParameter("@mark", SqlDbType.Int, 1, "mark")
    });
    adapter.UpdateCommand = connection.CreateCommand();
    adapter.UpdateCommand.CommandText = "update studentsubject set mark = @mark";
    adapter.UpdateCommand.Parameters.Add("@mark", SqlDbType.Int, 1, "mark");
    adapter.DeleteCommand = connection.CreateCommand();
    adapter.DeleteCommand.CommandText = "declare @subject_id int; select @subject_id = subject_id from studentsubject where id = @id; delete from studentsubject where id = @id; delete from [subject] where id = @subject_id";
    adapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, int.MaxValue, "id");
