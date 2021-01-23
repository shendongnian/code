    public delegate void LFC(Serial target);
    
    [ServerMessageHandler(0x3C)]
      public CallbackResult ContainerContains(byte[] data, CallbackResult prevResult)
      {
       PacketReader reader = new PacketReader(data);
       reader.Skip(3);
    
       ushort len = reader.ReadUInt16();
       for (int i = 0; i < len; i++)
       {
          Serial serial = (Serial)(reader.ReadUInt32());
          ushort graphic = (ushort)(reader.ReadUInt16());
    
          reader.Skip(7);
    
          Serial container = (Serial)(reader.ReadUInt32());
          ushort color = (ushort)(reader.ReadUInt16());
    	
    	LFC = lootfromcontainer = new LFC(LOOT_FromContainer);
    	
          if (((int)graphic == 0x0E76) && ((int)color == 0x049A))
          {
    		lootfromcontainer.BeginInvoke(container, null, null);
             //LOOT_FromContainer.BeginInvoke(container);
          }
       }
       return CallbackResult.Normal;
      }
    
    
    [Command]
    public static void LOOT_FromContainer(Serial target)
    {
       UOItem lootCorpse = new UOItem(target);
          if (lootCorpse.Graphic == 0x2006)
          {
              if (((draw == 1) && (World.Player.Backpack.AllItems.Count(draw_knife[0], draw_knife[1]) > 0)) || (World.Player.Layers[Layer.RightHand].Exist))
              {
                  if ((lootCorpse.Amount != 400) && (lootCorpse.Amount != 401))
                  {
                      if (draw == 0)
                      {
                          UO.WaitTargetObject(lootCorpse);
                          UO.UseObject(World.Player.Layers[Layer.RightHand].Serial);
                      }
                      else
                      {
                          UO.WaitTargetObject(lootCorpse);
                          UO.UseType(draw_knife[0], draw_knife[1]);
                      }
                      UO.Wait(500);
                  }
              }
              else
          {
                 UO.Print("Neni cim rezat, pouze lootim");
          }
    
              for (int i = 0; i < loot.Length; i++)
              {
             if (lootCorpse.Items.Count(loot[i][0], loot[i][1]) > 0)
                  {
                if (loot[i][2] == 1)
                {
                   if (loot[i][4] == 1)
                   {
                      UO.MoveItem(lootCorpse.Items.FindType(loot[i][0], loot[i][1]), 0, Aliases.GetObject("loot_bag"), loot[i][5], loot[i][6]);
                        UO.Wait(200);
                   }
                   else
                   {
                      UO.MoveItem(lootCorpse.Items.FindType(loot[i][0], loot[i][1]), 0, World.Player.Backpack);
                          UO.Wait(200);
                   }
                }
                  }
              }
          }
    }
