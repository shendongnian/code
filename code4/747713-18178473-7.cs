    public PendingOrder placeOrderWith(Address deliveryAddress,
			Date deliveryTime) {
        if (restaurantRepository.isAvailableFor(deliveryAddress, deliveryTime)) {
            return new PendingOrder(pendingOrderRepository.nextTrackingId(),
					deliveryAddress, deliveryTime);
        } else {
            throw new NoAvailableRestaurantException(deliveryAddress,
					deliveryTime);
        }
    }
