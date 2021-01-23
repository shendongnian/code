    private void Instalarbtn_Click(object sender, RoutedEventArgs e) {
      string appFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
      string MinecraftFolder = Path.Combine(appFolder, "minecraft");
      string destinationFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "system.zip");
      FastZip FastZip = null;
      string minecraftTemp = Path.Combine(MinecraftFolder, "temp");
      if (Directory.Exists(minecraftTemp)) {
        Directory.Delete(minecraftTemp, true);
      }
      string minecraftBin = Path.Combine(MinecraftFolder, "bin");
      string minecraftTempMinecraft = Path.Combine(minecraftTemp, "Minecraft");
      FastZip.ExtractZip(minecraftBin, minecraftTempMinecraft, String.Empty);
      string minecraftTempMinecraftMETAINF = Path.Combine(minecraftTempMinecraft, "META-INF");
      try {
        Directory.Delete(minecraftTempMinecraftMETAINF, true);
      } catch (DirectoryNotFoundException e1) {
      }
      FastZip.ExtractZip(destinationFile, minecraftTemp, String.Empty);
      string minecraftBinMinecraftJar = Path.Combine(minecraftBin, "minecraft.jar");
      FastZip.CreateZip(minecraftBinMinecraftJar, minecraftTempMinecraft, true, String.Empty);
      if (Directory.Exists(minecraftTemp)) {
        Directory.Delete(minecraftTemp, true);
        MessageBox.Show("Instalado correctamente", "Instalador");
      }
    }
