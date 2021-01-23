    private void MarkAs(User user, UserAddress address, User.AddressType type) {
			if (context.Entry(user).State == EntityState.Detached) {
				// clear navigation properties before attaching the entity
				user.DefaultInvoiceAddress = null;
				user.DefaultDeliveryAddress = null;
				user.AllAddresses = null;
				context.Users.Attach(user);
			}
			// address doesn't have to be attached
			if (type.HasFlag(User.AddressType.DefaultInvoice)) {
				// previously I tried to clear the navigation property here
				user.DefaultInvoiceAddressId = address.Id;
				context.Entry(user).Property(u => u.DefaultInvoiceAddressId).IsModified = true;
			}
			if (type.HasFlag(User.AddressType.DefaultDelivery)) {
				user.DefaultDeliveryAddressId = address.Id;
				context.Entry(user).Property(u => u.DefaultDeliveryAddressId).IsModified = true;
			}
		}
