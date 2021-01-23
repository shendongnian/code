     if (IsAuthenticatedValue) //You can adjust  your condition
      {
          FormsAuthentication.RedirectFromLoginPage (.., ..);
      }
      else
      {
          Console.WriteLine("Invalid credentials. Please try again.");
      }
