    connextion.Execute(sql, new {
        username = username.Text,
        id = 123, // theses are all invented, obviously
        foo = "abc",
        when = DateTime.UtcNow
    });
