    new Thread(
      (temp_bot) =>
        {
          int crashes = 0;
          while (crashes < 1000)
          {
            try
            {
               temp_bot = new Bot(config, sMessage, ConvertStrDic(offeredItems),
               ConvertStrDic(requestedItems), config.ApiKey,
                 (Bot bot, SteamID sid) =>
                   {
                     return (SteamBot.UserHandler)System.Activator.CreateInstance(
                     Type.GetType(bot.BotControlClass), new object[] { bot, sid });
                   },
                 false);
            } 
          catch (Exception e)
          {
            Console.WriteLine("Error With Bot: " + e);
            crashes++;
          }
        }
      }
    ).Start();
