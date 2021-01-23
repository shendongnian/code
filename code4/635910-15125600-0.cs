    @{
        Page.Title = "";
        Layout = "~/_Layout.cshtml";
        if(IsPost)
        {
            string username = Request["username"]; // the request calls the input named "username"
            // here you can type in any C# code you wish
        }
    }
    <div>
        <form action="" method="post">
            <input type="text" name="username" />
            <input type="submit" value="btn2" />
        </form>
    </div>
