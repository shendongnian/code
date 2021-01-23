    list.Select(u =>
        {
            var pin = string.Empty;
            if (u.Pin != null)
            {
                pin = u.Pin.UserPin;
            }
            return new
            {
                Cell = new object[]
                {
                    u.UserId.ToString(),
                    u.UserName, 
                    u.Password,
                    pin
                }
            };
        });
