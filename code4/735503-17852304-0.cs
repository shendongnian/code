        var lst = new List<string>
                      {
                          "asif1@cc.com my company1aa1 viewed profile abc@gmail.com my name",
                          "asif2@cc.com my company1aa2 viewed profile cv3@cc.com cv 3",
                          "asif3@cc.com my company1aa3 viewed profile cv2@cc.com cv 2",
                          "asif4@cc.com my company1aa4 viewed profile cv4@cc.com cv 4",
                          "asif5@cc.com my company1aa5 viewed profile CV1@cc.com cv 1"
                      };
        foreach (var str in lst)
        {
            var i = str.IndexOf("viewed", StringComparison.OrdinalIgnoreCase);
            var part1 = str.Substring(0, i - 1); // -1 ommits the space before "viewed"
            var employerEmail = part1.Substring(0, part1.IndexOf(" ", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("EmployerEmail :" + employerEmail);
            var companyName = part1.Substring(part1.IndexOf(" ", StringComparison.OrdinalIgnoreCase) + 1); // +1 ommits the space
            Console.WriteLine("CompanyName :" + companyName);
            var part2 = str.Substring(i + 16); // +16 to start right after "viewed profile "
            var registrantEmail = part2.Substring(0, part2.IndexOf(" ", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("RegistrantEmail :" + registrantEmail);
            var fullName = part2.Substring(part2.IndexOf(" ", StringComparison.OrdinalIgnoreCase) + 1); // +1 ommits the space
            Console.WriteLine("FullName :" + fullName);
        }
