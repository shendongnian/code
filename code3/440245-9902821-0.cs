            Page landingPage = new Page(c);
            RedeemPage redeemPage = new RedeemPage(c);
            PageRepository.Add(landingPage);
            PageRepository.Add(redeemPage);
            c.LandingPage = landingPage;
            c.RedeemPage = redeemPage;
            Campaignrepository.Update(c);
