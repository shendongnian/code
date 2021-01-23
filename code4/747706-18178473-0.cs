    @Transactional
    @Override
    public PendingOrder placeOrder(Address deliveryAddress, Date deliveryTime) {
        PendingOrder pendingOrder = new PendingOrder(
				pendingOrderRepository.nextTrackingId(), deliveryAddress,
				deliveryTime);     //by constructor
        pendingOrderRepository.store(pendingOrder);
        return pendingOrder;
    }
