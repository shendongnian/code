    this.ToTable("ExchangerToPaymentSystem");
                this.HasKey(e => e.Id);
                
                this.HasRequired(e => e.Exchanger )
                    .WithMany(e => e.ExchangersSupport )
                    .HasForeignKey(pc => pc.ExchangerId);
    
    
                this.HasRequired(pc => pc.PaymentSystem )
                    .WithMany(p => p.PaymentSystems)
                    .HasForeignKey(pc => pc.PaymentSystemId);
