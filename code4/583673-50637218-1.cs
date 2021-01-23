        public IActionResult Client(string username)
        {
            var client = HttpContext.Items["profile"] as Client;
            var model = new
            {
                client.Id,
                client.Name,
                client.Surname,
                client.Username,
                client.Photo,
                CoverPhoto = new {
                   client.CoverPhoto.Source,
                   client.CoverPhoto.X
                }.ToExpando(),
            }.ToExpando();
            return View(model);
        }
