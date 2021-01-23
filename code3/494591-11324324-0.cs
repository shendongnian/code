    var damager = collision.gameobject.GetComponent<DamageVolume>();
    if (damager != null) {
        if (damager.InstantKill) {
            this.Kill(damager.DamageType);
        }
        else {
            this.Damage(damager.DamageAmount, damager.DamageType);
        }
    }
