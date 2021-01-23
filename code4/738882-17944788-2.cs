    var ammoBox = new AmmoBox();
    var clip = new Clip();
    
    var clipWeapon = new ClipWeapon();
    clipWeapon.Reload(ammoBox);
    clipWeapon.Reload(clip);
    
    var ammoBoxWeapon = new AmmoBoxWeapon();
    ammoBoxWeapon.Reload(ammoBox);
